using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IN3.Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReverseController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("{sentence}")]
        public ActionResult<string> Get(string sentence)
        {
            return Ok(ReverseSentenceWords(sentence));
        }


        // POST api/values
        private string ReverseSentenceWords(string sentence)
        {
            List<char> output = new List<char>();
            // Create stack for reversing the word
            var reverseStack = new Stack<char>();
            foreach (var c in sentence)
            {
                // If we face a puctuation or symbol or space
                // the we have a word before in the reverse stack
                if (char.IsPunctuation(c) || char.IsSymbol(c) || c.Equals(' '))
                {
                    // pop all
                    while (reverseStack.Count > 0)
                    {
                        output.Add(reverseStack.Pop());
                    }
                    // add the special character.
                    output.Add(c);
                }
                else
                {
                    // add the character to the reverse atack.
                    reverseStack.Push(c);
                }
            }

            // after finsh loping over sentence's chars and the stack is not empty 
            // (the last word not ended by specail character.)
            // pop all from the reverse stack.
            while (reverseStack.Count > 0)
            {
                output.Add(reverseStack.Pop());
            }

            return new string(output.ToArray());
        }


    }
}
