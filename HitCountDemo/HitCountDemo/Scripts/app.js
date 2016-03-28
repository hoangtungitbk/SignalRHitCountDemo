$(function () {

    function display(data) {
        if (data !== undefined && data.length) {
            $('#productlist').html('');
            var str = '<tr><th>Id</th><th>Name</th><th>Price</th></tr>';
            if (data.length == 0) {
                str += '<tr><td colspan="4">Không có dữ liệu</td></tr>';
            } else {
                $.each(data, function (index, item) {
                    str += '<tr><td>' + item.Id + '</td><td>' + item.Name + '</td><td>' + item.Price + '</td></tr>';
                });
                $('#productlist').append(str);
            }
        }
    };

    var conn = $.hubConnection();
    var hub = conn.createHubProxy('productHub');

    hub.on('getAll', function (data) {
        display(data);
    });
    $('#btnSave').click(function () {
        event.preventDefault();
        var data = {
            Id: $("#productId").val(),
            Name: $("#productName").val(),
            Price: $("#productPrice").val()
        }
        hub.invoke('addProduct', data);
        $("#productId, #productName, #productPrice").val("");
        $("#productId").focus();
    });

    conn.start().done(function () {
        hub.invoke('loadProduct');
    });
});