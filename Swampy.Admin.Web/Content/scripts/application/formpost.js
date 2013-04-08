(function ($) {

    jQuery.fn.extend({
        postForm: function(options) {

            //by default use parent form target, unless specifically require to use anchor href
            var defaults = {
                useAnchorHrefAsTarget: false
            };

            var options = $.extend(defaults, options);

            var $form = $(this).parents('form');

            var url;

            if (options.useAnchorHrefAsTarget) {
                url = this.href;
            } else {
                url = $form.attr('action');
            }

            $.ajax({
                url: url,
                data: $form.serialize(), //parameters go here in object literal form
                type: 'POST',
                success: function(data) { alert('got here with data'); },
                error: function() { alert('something bad happened'); }
            });


            return this;

        }
    });
})(jQuery);