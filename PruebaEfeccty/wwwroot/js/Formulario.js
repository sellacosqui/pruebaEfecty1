
function newItem() {
    debugger
    $("#Formularioid").val(0);
    $('#formData')[0].reset();
    clearForm();
    cargardatos();
}

    function Guardar(e) {
        debugger;
        try {
            let Formularioid = parseInt($("#Formularioid").val().trim());
            var form = $("#formData");
            
                var url = "";
                if (Formularioid === 0 || Formularioid === "") {
                    url = '/Formulario/Create';
                    var data = {
                        Nombre: $("#Nombre").val().trim(),
                        Apellido: $("#Apellido").val().trim(),
                        Estado_Civil: $('#Estado_Civil').prop('checked'),
                        Tipo_Identificacion: $("#Tipo_Identificacion").val().trim(),
                        Sueldo: $("#Sueldo").val().trim(),
                        Fecha_Nacimiento: $("#Fecha_Nacimiento").val().trim(),
                    };
                }
                else {
                    url = '/Formulario/Edit';
                    var data = {
                        Id: Formularioid,
                        Nombre: $("#Nombre").val().trim(),
                        Apellido: $("#Apellido").val().trim(),
                        Estado_Civil: $('#Estado_Civil').prop('checked'),
                        Tipo_Identificacion: $("#Tipo_Identificacion").val().trim(),
                        Sueldo: $("#Sueldo").val().trim(),
                        Fecha_Nacimiento: $("#Fecha_Nacimiento").val().trim(),
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
    cargardatos();
        try {
            let url = '/Formulario/Edit/' + id;
            
            clearForm();
            $.get(url, function (data) {
                console.log(data);
                ;
                if (data.isSuccess) {
                    debugger
                    $("#formModalLabel").text('Editar Formulario');
                    $("#Formularioid").val(data.result.id);
                    $("#Nombre").val(data.result.nombre);
                    $("#Apellido").val(data.result.apellido);
                    $("#Sueldo").val(data.result.sueldo);
                    $("#Tipo_Identificacion").val(data.result.tipo_Identificacion);
                    $("#Fecha_Nacimiento").val(data.result.fecha_Nacimiento.toString().split('T')[0]);
                    $('#Tipo_Identificacion  option[value="' + data.result.tipo_Identificacion + '"]').prop("selected", true);
                    if (data.result.estado_Civil)
                        $("#Estado_Civil").prop("checked", true);
                    $("#formModal").modal('show');
                } else {
                    material.showSwal('error-not', 'Error al cargar información', 2000);
                }
            });
        } catch (e) {
            console.log(e.message);
        }
    }



function  deleteItem(id) {
        try {
            let url = '/Formulario/Delete/' + id;
           
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

function Refrescar() {
    try {
        ;
        let url = '/Formulario/data';
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

function cargardatos() {
    try {
        ;
        let url = '/Formulario/Tipo_Identificacion';
        $.get(url, function (data) {
            console.log(data);
            ;
            if (data != "") {
                debugger
                const select = document.getElementById('Tipo_Identificacion');
                for (let i = select.options.length; i >= 1; i--) {
                    select.remove(i);
                }
                for (var i = 0; i < data.length; i++) {
                    const option = document.createElement('option');
                    option.value = data[i].id;
                    option.text = data[i].descripcion;
                    select.appendChild(option);
                }
            } else {

            }
        });
    } catch (e) {
        console.log(e.message);
    }
}

function   clearForm() {
        // ;
        $("#Nombre").val('');
        $("#Apellido").val('');
        $("#Sueldo").val('');
        $("#Tipo_Identificacion").val('');
        $("#Fecha_Nacimiento").val('');
        $('#Tipo_Identificacion option[value=""]').attr('selected', 'selected');
        $("#Estado_Civil").prop("checked", false);
    }
