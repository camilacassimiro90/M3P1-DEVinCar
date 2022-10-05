using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.DTOs
{
    public class ErrorDTO
    {
        public string Error { get; set; }
        public int Status { get; set; }
        public ErrorDTO(string error)
        {
            Error = error;
            Status = Status;

        }

        public ErrorDTO()
        {
        }
    }
}
