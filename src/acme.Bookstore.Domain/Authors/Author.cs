using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using JetBrains.Annotations;

namespace acme.Bookstore.Authors
{
    public class Author:FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime BirthDay { get; set; }

        public string ShortBio { get; set; }

        private Author() { }
        internal Author(Guid id,[NotNull] string name, DateTime birthDay, 
            [CanBeNull]string shortBio):base(id)
        {
            this.SetName(name);
            BirthDay = birthDay;
            ShortBio = shortBio;
        }

        internal Author ChangeName([NotNull]string name)
        {
            this.SetName(name);
            return this;
        }

        private void SetName([NotNull]string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AuthorConsts.MaxNameLength);
            this.Name = name;
        }
    }
}
