using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.Entidades.Base
{
    public class BaseLN: Controller
    {
        protected log4net.ILog Log
        {
            get
            {
                return
                log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().GetType());
            }
        }
    }

}
