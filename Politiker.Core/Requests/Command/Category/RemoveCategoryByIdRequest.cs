using Kernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Requests.Command.Category
{
    public class RemoveCategoryByIdRequest : ICommand
    {
        public int Id { get; set; }

        public RemoveCategoryByIdRequest(int id)
        {
            Id = id;
        }
    }
}
