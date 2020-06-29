using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class VirtualPalletSaveResultSource
    {
        public string Id { get; }
        public int ActualStep { get; }
        public int MaximumNumberOfSteps { get; }

        public VirtualPalletSaveResultSource(string id, int actualStep, int maximumNumberOfSteps)
        {
            Id = id;
            ActualStep = actualStep;
            MaximumNumberOfSteps = maximumNumberOfSteps;
        }
    }
}
