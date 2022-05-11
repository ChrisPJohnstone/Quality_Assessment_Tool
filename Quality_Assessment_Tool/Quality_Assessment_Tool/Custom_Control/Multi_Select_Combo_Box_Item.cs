using System;
using System.Collections.Generic;
using System.Text;

namespace Quality_Assessment_Tool
{
    public class MultiSelectComboBoxItem
    {
        private string key;
        public string Value
        {
            get { return key; }
            set { key = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public MultiSelectComboBoxItem()
        {
        }

        public MultiSelectComboBoxItem(string key, string name)
        {
            this.key = key;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("name: '{0}', value: {1}", name, key);
        }
    }
}
