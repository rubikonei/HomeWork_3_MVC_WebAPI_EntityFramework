$(function () {
    $(".offButton").click(function () {
        var id = $(this).parent().attr("id");
        $.ajax({
            url: "/api/values/off/" + id,
            type: "PUT",
            success: function (data) {
                updateData(data, id);
            }
        });
    });
    $(".minusButton").click(function () {
        var id = $(this).parent().attr("id");
        $.ajax({
            url: "/api/values/decreaseTemperature/" + id,
            type: "PUT",
            success: function (data) {
                updateData(data, id);
            }
        });
    });
    $(".plusButton").click(function () {
        var id = $(this).parent().attr("id");
        $.ajax({
            url: "/api/values/increaseTemperature/" + id,
            type: "PUT",
            success: function (data) {
                updateData(data, id);
            }
        });
    });
    $(".autoButton").click(function () {
        var id = $(this).parent().attr("id");
        $.ajax({
            url: "/api/values/setAutoTemperature/" + id,
            type: "PUT",
            success: function (data) {
                updateData(data, id);
            }
        });
    });
    $(".countEnergyButton").click(function () {
        var id = $(this).parent().attr("id");
        $.ajax({
            url: "/api/values/countEnergy/" + id,
            type: "PUT",
            success: function (data) {
                updateData(data, id);
            }
        });
    });
    $(".offFanButton").click(function () {
        var id = $(this).parent().attr("id");
        $.ajax({
            url: "/api/values/offFan/" + id,
            type: "PUT",
            success: function (data) {
                updateData(data, id);
            }
        });
    });
    $(".removeButton").click(function () {
        var id = $(this).parent().attr("id");
        $.ajax({
            url: "/api/values/delete/" + id,
            type: "DELETE",
            success: function (data) {
                $("#" + id).remove();
            }
        });
    });
});

function updateData(data, id) {
    $("#" + id).children(".power").text(data['Power']);

    if (data['State'] == true) {
        $("#" + id).children(".state").text("Включен");
    }
    else {
        $("#" + id).children(".state").text("Выключен");
    }

    $("#" + id).children(".temperature").text(data['Temperature']);

    $("#" + id).children(".temperatureEnvironment").text(data['TemperatureEnvironment']);

    $("#" + id).children(".allPower").text(data['AllPower']);

    if (data['Fan'] == true) {
        $("#" + id).children(".fanState").text("Включен");
    }
    else {
        $("#" + id).children(".fanState").text("Выключен");
    }
};