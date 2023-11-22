using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Application.Interfaces
{
    public interface ILogApplicationService
    {
        void InicioProcesso();
        void Salvar(string msg, bool erro = false);
        void FimProcesso(bool erro = false);
        void AdicionarLinha(string message = "");

    }
}
