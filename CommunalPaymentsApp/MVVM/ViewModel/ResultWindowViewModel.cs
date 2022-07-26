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
        public int NumberOfResidents { get; set; }
        public double TotalAmountResult { get; set; }
        public double Debt { get; set; }
        public ResultWindowViewModel(List<ServiceParameter> serviceParameters, int numberOfResidents, double debt)
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
            NumberOfResidents = numberOfResidents;
            Debt = debt;
            TotalAmountResult = emptyServiceParameter.Result + debt;
        }

    }
}
