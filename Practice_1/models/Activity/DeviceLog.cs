using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

using System.Collections.Generic;

namespace Practice_1.models.Activity
{//Главная папка, содержащая разделы
    public class DeviceLog
    {
        public Header Header { get; set; }//общая информация
        public List<Sample> Samples { get; set; }//сырые данные
        public List<WindowWrapper> Windows { get; set; }//список кругов
    }
}