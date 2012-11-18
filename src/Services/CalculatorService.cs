//
// HelloService.cs
//
// Author:
//       Tony Alexander Hild <tony_hild@yahoo.com>
//
// Copyright (c) 2012 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using System.Globalization;

namespace HelloServices
{
    /// <summary>
    /// Define your ServiceStack web service request (i.e. the Request DTO).
    /// </summary>
    [Route("/calculate/{Operand1}/{Operator}/{Operand2}")]
    public class Calculator
    {
        public string Operand1 { get; set; }

        public string Operand2 { get; set; }

        public string Operator { get; set; }
    }
    
    /// <summary>
    /// Define your ServiceStack web service response (i.e. Response DTO).
    /// </summary>
    public class CalculatorResponse
    {
        public string Result { get; set; }
    }
    
    /// <summary>
    /// Create your ServiceStack web service implementation.
    /// </summary>
    public class CalculatorService : IService<Calculator>
    {
        public object Execute (Calculator request)
        {
            var nf = CultureInfo.GetCultureInfo("en-US").NumberFormat;
            double operand1 = Convert.ToDouble(request.Operand1, nf);
            double operand2 = Convert.ToDouble(request.Operand2, nf);
            double v = 0;
            switch (request.Operator) {
            case "+":
            case "plus":
            case "add":
                v = operand1 + operand2;
                break;
            case "-":
            case "minus":
            case "subtract":
                v = operand1 - operand2;
                break;
            case "*":
            case "x":
            case "X":
            case "times":
            case "multiply":
                v = operand1 * operand2;
                break;
            case "/":
            case "dividedby":
            case "divide":
                v = operand1 / operand2;
                break;
            default:
                break;
            } 
            return new CalculatorResponse { Result = v.ToString(nf) };
        }
    }
}

