﻿using System.IO;
using MemeVM.Runtime.Engine;

namespace MemeVM.Runtime.Handlers {
    class Cmp : IHandler {
        public OpCode Handles => OpCode.Cmp;
        public void Handle(VM machine, Body body, Instruction instruction) {
            dynamic one = machine.Stack.Pop(), two = machine.Stack.Pop();

            machine.Stack.Push(one == two);
        }

        public Instruction Deserialize(BinaryReader reader) =>
            new Instruction(OpCode.Cmp);
    }
}
