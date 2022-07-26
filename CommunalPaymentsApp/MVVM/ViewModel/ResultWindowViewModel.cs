using CommunalPaymentsApp.MVVM.Model;
using CommunalPaymentsApp.MVVM.Model.AbstractServiceParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunalPaymentsApp.MVVM.ViewModel
{
    public class ResultWindowViewModel
    {
        public List<ServiceParameter> ServiceParameters { get; set; }
        public ResultWindowViewModel(List<ServiceParameter> serviceParameters)
        {
            ServiceParameters = new List<ServiceParameter>(serviceParameters);
            ServiceParameter emptyServiceParameter = new EmptyServiceParamter();
            emptyServiceParameter.AutoResult = false;
            foreach (var item in serviceParameters)
            {
                if (item.AutoResult)
                {
                    emptyServiceParameter.Result += item.Result;

                }
            }
            ServiceParameters.Add(emptyServiceParameter);
        }

    }
}
