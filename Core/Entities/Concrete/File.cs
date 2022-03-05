using System;
using System.Collections.Generic;


namespace Core.Entities.Concrete
{
    public class File : IEntity
    {
        public File()
        {
            FileAuthenticates = new HashSet<FileAuthenticate>();
            FileClients = new HashSet<FileClient>();
            FileMentors = new HashSet<FileMentor>();
        }

        public Guid FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public virtual ICollection<FileAuthenticate> FileAuthenticates { get; set; }
        public virtual ICollection<FileClient> FileClients { get; set; }
        public virtual ICollection<FileMentor> FileMentors { get; set; }
    }
}
