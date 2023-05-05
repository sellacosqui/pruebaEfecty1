
function newItem() {
    debugger
    $("#Tipo_Identificacionid").val(0);
    $('#formData')[0].reset();
    clearForm();
}



   

    function Guardar(e) {
        debugger;
        try {
            let Tipo_Identificacionid = parseInt($("#Tipo_Identificacionid").val().trim());
            var form = $("#formData");
            
                var url = "";
                if (Tipo_Identificacionid === 0 || Tipo_Identificacionid === "") {
                    url = '/Tipo_Identificacion/Create';
                    var data = {
                        Descripcion: $("#Descripcion").val().trim(),
                       
                    };
                }
                else {
                    url = '/Tipo_Identificacion/Edit';
                    var data = {
                        Id: Tipo_Identificacionid,
                        Descripcion: $("#Descripcion").val().trim(),
                        
                    };
                }

                var json = JSON.stringify(data);
                $.ajax({
                    url: url,
                    type: 'post',
                    data: json,
                    contentType: 'application/json',
                    headers: { 'Accept': 'application/json' },
                    cache: false,
                    success: function (result) {
                        ;
                        if (result.isSuccess) {
                            $("#formModal").modal('hide');
                            Refrescar();
                        }
                        else {
                            
                            
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                    }
                });
            
        } catch (e) {
            console.log(e.message);
        }
};



function loadEdit(id) {
        try {
            let url = '/Tipo_Identificacion/Edit/' + id;
            
            clearForm();
            $.get(url, function (data) {
                console.log(data);
                ;
                if (data.isSuccess) {
                    debugger
                    $("#formModalLabel").text('Editar Tipo de Identificacion');
                    $("#Tipo_Identificacionid").val(data.result.id);
                    $("#Descripcion").val(data.result.descripcion);
                    $("#formModal").modal('show');
                } else {

                }
            });
        } catch (e) {
            console.log(e.message);
        }
    }

function Refrescar() {
    try {
        ;
        let url = '/Tipo_Identificacion/data';
        $.get(url, function (data) {
            console.log(data);
            ;
            if (data != "") {
                debugger
                $("#Data").html(data);
            } else {

            }
        });
    } catch (e) {
        console.log(e.message);
    }
}

function  deleteItem(id) {
        try {
            let url = '/Tipo_Identificacion/Delete/' + id;
           
                        $.get(url, function (data) {
                            console.log(data);
                            ;
                            if (data.isSuccess) {
                               
                            } else {
                              
                            }
                        });
                    
        } catch (e) {
            console.log(e.message);
        }
    }


function   clearForm() {
        // ;
    $("#Descripcion").val('');
    }
