using System;
using System.Collections.Generic;
using System.Text;
using Politiker.Core;

namespace Politiker.Infrastructure
{
    public interface ISeedTable<TEntity> where TEntity : BaseEntity
    {
        TEntity[] Seed();
    }
}
