// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DelProfile(isTrue) {
    if (isTrue) {
        $('#DelConfirm').show();
        $('#DelPrompt').hide();
    }
    else {
        $("#DelConfirm").hide();
        $("#DelPrompt").show();
    }
}

(function ($) {
    $(document).ready(function () {        

        $(".clSgst").prop("readonly", true);

        $(".clCgst").change(function () {
            var tax = $(this).val() * 2;

            switch (tax) {
                case 0:
                case 3:
                case 5:
                case 12:
                case 18:
                case 28:
                    $(".clSgst").val($(this).val());
                    break;
                default:
                    $(".clSgst").val("");
                    alert("Invalid GST %");
            }
        });

        $('#chkCopy').click(function () {
            if ($(this).is(":checked"))
                $('.Address2').val($('.Address1').val());
            else
                $('.Address2').val("");
        });

        $(".slab").on('change', function (e) {

            $("#tblSlab tbody").empty();            
            var custId = $('#UserId').val();
            var ptrId = $('#PrinterId').val();

            $.ajax({
                type: "GET",
                url: "/Inv/GetRates",
                data: { "custId": custId, "ptrId": ptrId },
                dataType: "json",
                success:
                    function (data) {
                        //console.log(data);                        

                        $.each(data, function (i, val) {                            
                            var markup = "<tr id=" + val.id + ">" +
                                "<td>" +
                                "<input id='Slab_Rates_" + i + "__ValFrom' name='Slab_Rates[" + i + "].valFrom' value=" + val.valFrom + " type='number' style='width:90px'/>" +
                                "</td>" +
                                "<td>" +
                                "<input id='Slab_Rates_" + i + "__ValTo' name='Slab_Rates[" + i + "].valTo' value=" + val.valTo + " type='number'style='width:90px'/>" +
                                "</td>" +
                                "<td>" +
                                "<input id='Slab_Rates_" + i + "__Rate' name='Slab_Rates[" + i + "].rate' value=" + val.rate + " style='width:50px'/>" +
                                "</td>" +
                                "</tr>";
                            $("#tblSlab tbody").append(markup);
                        });
                    },
                error: function (req, status, error) {
                    //alert(error);
                }
            })
        });
    });
})(jQuery);