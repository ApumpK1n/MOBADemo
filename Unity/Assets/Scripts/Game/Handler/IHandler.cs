using System;
using System.Collections.Generic;
using System.Linq;


namespace Pumpkin
{
    public interface IHandler
    {

        public void Handle(Cmd cmd);
    }
}
