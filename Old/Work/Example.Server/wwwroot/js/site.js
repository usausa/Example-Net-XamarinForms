﻿$(document).ready(function () {
    $(document).on("click", "button.confirm,a.confirm", function () {
        return confirm($(this).data("confirm-message"));
    });
});
