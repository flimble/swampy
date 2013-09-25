/*jslint browser: true, devel: true*/
/*global $, jQuery*/
(function ($) {
    "use strict";
    jQuery.fn.extend({
        postForm: function (options) {         
            var defaults, $form, url;
            //by default use parent from target, 
            //unless specifically require to use anchor href
            defaults = { useAnchorHrefAsTarget: false };
            options = $.extend(defaults, options);
            $form = $(this).parents('form');

            if (options.useAnchorHrefAsTarget) {
                url = this.href;
            } else {
                url = $form.attr('action');
            }

            $.ajax({
                url: url,
                data: $form.serialize(), //parameters go here in object literal form
                type: 'POST',
                success: function () { alert('got here with data'); }
            });
            return this;

        }
    });
}(jQuery));