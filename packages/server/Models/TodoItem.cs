using System;

namespace server.Models {
    public class TodoItem {
        public Guid Id { get; private set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Checked { get; set; }

        public TodoItem()
        {
            this.Id = Guid.NewGuid();
        }
    }
}