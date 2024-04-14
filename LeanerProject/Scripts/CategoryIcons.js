var modal = new bootstrap.Modal(document.getElementById("exLargeModal"));

$(".chooseIcon").click(function () {
    modal.show();
});

function ChooseIcon(data) {
    $.ajax({
        url: '/Category/ChooseIcon/',
        type: 'get',
        data: { resultData: data },
        success: function (jsonData) {
            if (jsonData == "err") {
                $(".SetIcon").empty();
                $("#alert1").fadeIn();
                document.querySelector(".selectedIconTxt").innerHTML = "";
                document.getElementById("alert1").innerHTML = "Aradığınız ikon bulunamadı";
            } else {
                $(".selectedIconTxt").fadeIn();
                $(".selectedIconTxt2").fadeIn();
                $(".SetIcon").fadeIn();
                document.querySelector(".selectedIconTxt").innerHTML = "<b>Seçilen İkon: " + data + "</b>";
                $(".SetIcon").empty();
                $(".SetIcon").append(`(<i class="${data}"></i>)`);

            }
        }
    });

    modal.hide();
}

function SearchIconFunction(data, ControllerName, ActionName, dataId) {

    if (data == "") {
 
        if (dataId == "") {
            window.location.href = "/" + ControllerName + "/" + ActionName + "?pageNumber=1&status=active";
        }
        else {
           
            window.location.href = "/" + ControllerName + "/" + ActionName + "/" + dataId + "?pageNumber=1&status=active";
        }

    }
    else {
        let div = ``;
        $(".IconsDiv").empty();
        $.ajax({
            url: '/Category/SearchData/',
            type: 'get',
            data: { IconName: data },
            success: function (result) {
                $.each(result, (index, item) => {

                    div += `<a id="test" onclick="ChooseIcon('${item.IconType}')" style=" color:grey; cursor:pointer;"><i style="font-size:20pt" class="${item.IconType} Icon"></i></a>`;

                });
                $(".IconsDiv").html(div);
            }
        });
    }

}
