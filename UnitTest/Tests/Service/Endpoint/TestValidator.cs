using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Swampy.Business.Contract.Validators
{
    public class TestValidator<T> : InlineValidator<T>
    {
        public TestValidator()
        {

        }

        public TestValidator(params Action<TestValidator<T>>[] actions)
        {
            foreach (var action in actions)
            {
                action(this);
            }
        }
    }


}
