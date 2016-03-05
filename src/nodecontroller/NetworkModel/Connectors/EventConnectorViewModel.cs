using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkModel
{
    // ノード自体が持つイベントの進行接続状態を表すために存在するので実体は持たない(ダミーデータ)
    public class EventConnectorViewModel : ConnectorViewModel
    {
        public EventConnectorViewModel() : base("no name#"+Guid.NewGuid().ToString("N"),typeof(EventData), EntityGroupTypes.Event)
        {
            this.ConnectorNameVisibility = false;
        }

        public new EventData Entity
        {
            get
            {
                if (entity == null) entity = new EventData();
                return (EventData)Convert.ChangeType(entity, typeof(EventData));
            }
            set { this.SetProperty(ref entity, value); }
        }


    }
}
