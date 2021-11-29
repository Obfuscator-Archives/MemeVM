﻿using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using MemeVM.Translation.Helpers;

namespace MemeVM.Translation.Handlers {
    class Ldarg : IHandler {
        public OpCode[] Translates => new[] { OpCodes.Ldarg };
        public VMOpCode Output => VMOpCode.Ldarg;
        public VMInstruction Translate(VMBody body, MethodDef method, int index, Offsets helper, out bool success) {
            var arg = (short)method.Parameters.IndexOf((Parameter)method.Body.Instructions[index].Operand);
            success = true;
            return new VMInstruction(VMOpCode.Ldarg, arg);
        }

        public byte[] Serialize(VMBody body, VMInstruction instruction, Offsets helper) {
            var buf = new byte[3];
            buf[0] = (byte)VMOpCode.Ldarg;
            Array.Copy(BitConverter.GetBytes((short)instruction.Operand), 0, buf, 1, 2);
            return buf;
        }
    }
}
