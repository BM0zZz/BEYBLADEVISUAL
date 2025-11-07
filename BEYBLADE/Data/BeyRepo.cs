// Data/BeyRepo.cs
using System.Collections.Generic;
using System.Linq;
using BEYBLADE.Models;

namespace BEYBLADE.Data
{
    public static class BeyRepo
    {
        private static readonly List<Beyblade> _items = new List<Beyblade>();
        public static List<Beyblade> Items { get { return _items; } }

        public static void Add(Beyblade b)
        {
            if (b == null) return;
            _items.Add(b);
        }

        public static Beyblade Find(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            var lower = name.ToLower();
            return _items.FirstOrDefault(x => (x.Name ?? "").ToLower() == lower);
        }

        public static bool Remove(string name)
        {
            var b = Find(name);
            if (b == null) return false;
            _items.Remove(b);
            return true;
        }
    }
}
