using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Faker.Core
{
    internal class ObjRecursionManager
    {
        private Dictionary<Type, int> recursions = new Dictionary<Type, int>();
        private int maxRecursions;

        public ObjRecursionManager(int maxRecursions)
        {
            this.maxRecursions = maxRecursions;
        }

        public bool tryEnterRecursion(Type t)
        {
            if (!recursions.TryAdd(t, 1))
            {
                var curRecursions = recursions[t];
                if (curRecursions > maxRecursions)
                    return false;
                recursions[t]++;
            }
            return true;
        }
        public void leaveRecursion(Type t)
        {
            recursions[t]--;
        }
    }
}
