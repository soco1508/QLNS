using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS_SGU.Presenter
{
    public interface IPresenterArgumentForTabPage
    {
        void Initialize(string s, int tabOrder);
        object UI { get; }
    }
}
