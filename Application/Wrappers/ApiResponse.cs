﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse() { }
        //Success
        public ApiResponse(T data,string message=null) { 
            Succeeded = true;
            Message = message;
            Data = data;
        }
        //Fail
        public ApiResponse(string message) {
            Succeeded=false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
