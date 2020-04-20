using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Program.Result
{
    public class ProgramStepResult
    {
        public int ProgramStepId { get; }
        public float Result1 { get; }
        public float Result2 { get; }
        public float Result3 { get; }
        public float Result4 { get; }
        public float Result5 { get; }
        public string WorkspaceSlot { get; }
        public LocalDateTime LocalDateTime { get; }

        public ProgramStepResult(int programStepId,
            float result1,
            float result2,
            float result3,
            float result4,
            float result5,
            string workspaceSlot,
            LocalDateTime localDateTime)
        {
            ProgramStepId = programStepId;
            Result1 = result1;
            Result2 = result2;
            Result3 = result3;
            Result4 = result4;
            Result5 = result5;
            WorkspaceSlot = workspaceSlot;
            LocalDateTime = localDateTime;
        }
    }
}
