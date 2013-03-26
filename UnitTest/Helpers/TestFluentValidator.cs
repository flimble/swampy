using System;
using FluentValidation;

namespace Swampy.UnitTest.Helpers
{
    public class TestFluentValidator<T> : InlineValidator<T>
    {
        public TestFluentValidator()
        {

        }

        public TestFluentValidator(params Action<TestFluentValidator<T>>[] actions)
        {
            foreach (var action in actions)
            {
                action(this);
            }
        }
    }


}
