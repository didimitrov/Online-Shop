﻿$(function () {
    (function () {
        debugger;
        var currentId = $("#storyMIN").val();
        var activUl = $("li").find("[data-slide-to='" + currentId + "']");
        var activDiv = $("div").find("[data-storyid='" + currentId + "']");
        activUl.addClass("active");
        activDiv.addClass("active");
    })();
});