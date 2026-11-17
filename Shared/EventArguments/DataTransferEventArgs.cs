using System;
using System.Collections.Generic;
using Shared.DTO;

namespace Shared.EventArguments
{
    public class DataTransferEventArgs : EventArgs
    {
        public List<SushnostDto> Data { get; }
        public double Stability { get; }

        public DataTransferEventArgs(List<SushnostDto> data, double stability)
        {
            Data = data;
            Stability = stability;
        }
    }
}