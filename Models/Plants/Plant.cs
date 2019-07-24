using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Plant : IResource
    {
        public virtual string Type {get;}

        private Guid _id = Guid.NewGuid();

        public string ShortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

    }
}