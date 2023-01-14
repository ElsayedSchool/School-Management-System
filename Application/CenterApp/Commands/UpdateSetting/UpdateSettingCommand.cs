using Application.CenterApp.Query.GetSetting;
using Application.Common.Mediatr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp{
    public class UpdateSettingCommand : IRequestWrapper<bool>
    {
        public int Id { get; set; }
        public SettingDetailVm Data { get; set; }
    }
}
