using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Robot:IInfo
{
    public string Name { get; private set; }
    public string Id { get; private set; }

    public Robot(string name, string id)
    {
        this.Name = name;
        this.Id = id;
    }
}
