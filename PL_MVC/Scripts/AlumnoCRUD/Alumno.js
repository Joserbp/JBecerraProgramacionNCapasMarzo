$(document).ready(function () { 
    GetAll();
});

function SoloLetras(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    // Patrón de entrada, en este caso solo acepta numeros y letras
    patron = /[A-Za-z1]/;
    tecla_final = String.fromCharCode(tecla);
    //  IF
    //Implementar algun detalle visual // Label que solo permite letras °°  Pintar el borde el input de rojo °° Pintar el borde de verde
    return patron.test(tecla_final);
}
function SoloNumero(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    // Patrón de entrada, en este caso solo acepta numeros y letras
    patron = /[0-9]/;
    tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}
function Curp(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    // Patrón de entrada, en este caso solo acepta numeros y letras
    patron = /[A-Za-z1]/;
    tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}
//function Elminar(IdAlumno) {

//    //CREAR PETCION AJAX para el ENDPOINT de DELETE
//    success: function(resul) {
//        alert(result.correct + "Producto elimnaod")
//    }

//    Error{
//        alert("ocurrio un error" + result.ErrorMessage)
//    }
//}

function showForm() {
    $('#ModalUpdate').modal('show');
    //Acceder al id Button Update Ocultar
    //Acceder al id Button Add Mostrar
}


function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58535/api/alumno/',
        success: function (result) { //200 OK 
            $("#alumno tbody").empty();
            $.each(result.Objects, function (i, alumno) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById('+ alumno.IdAlumno+')">'
                    + '<img  style="height: 25px; width: 25px;" src="../img/edit.ico" />'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center'>" + alumno.Nombre + "</td>"
                    + "<td class='text-center'>" + alumno.ApellidoPaterno + "</td>"
                    + "<td class='text-center'>" + alumno.ApellidoMaterno + "</ td>"
                    + "<td class='text-center'>" + alumno.FechaNacimiento + "</td>"
                    /*+ "<td class='text-center'>" + alumno.Semestre.idSemestre + "</td>"
                    + "<td class='text-center'>" + alumno.Direccion.Colonia.Municipio.Estado.Pais.Nombre + "</td>"*/
                    //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + alumno.IdAlumno + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#alumno tbody").append(filas); 
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function GetById(IdAlumno) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:58535/api/alumno/' + IdAlumno,
        success: function (result) {
            $('#txtIdAlumno').val(result.Object.IdAlumno);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#txtUserName').val(result.Object.UserName);
            //Acceder al id Button Update Mostrar
            //Acceder al id Button Add Ocultar
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.ErrorMessage);
        }


    });
}

//function add() {
    //Recuperar los datos de sus input
    //Crear el JSON
    //Mandarlo en la data
    //Success
        //Alert Agregado
        //Actualizar la tabla GETALL()
//   type //POST
//}
//function Update() {
//    var idAlumno = $('#txtIdAlumno').val()
//    var alumno = {
//        IdAlumno: idAlumno
//    }

//    type //PUT
//    url
//    data = alumno
//    success(){

//    }
//}