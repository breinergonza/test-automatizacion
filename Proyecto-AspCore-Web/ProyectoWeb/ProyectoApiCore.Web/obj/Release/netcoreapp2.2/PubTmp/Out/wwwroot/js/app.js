$(function () {
  //SE INICIALIZZ MOSTRANDO SOLO EL DIV DE PROYECTOS
  $('#tareas').hide();
  $('#equipos').hide();
  $('.proyectos').show();
  fetch('https://ctrelo.azurewebsites.net/api/Proyectos/todos')
    .then((respuesta) => {
      return respuesta.json();
    })
    .then((respuesta) => {
      guardarProyectos(respuesta)
    })
})


function guardarProyectos(proyectos) {//DESPUES DE LA CONSULTA SE GUARDAN LOS DATOS DE TODOS LOS PROYECTOS
  var nombreProyecto
  var descripcionProyecto
  for (const i in proyectos) {
    nombreProyecto = proyectos[i].nombreProyecto
    descripcionProyecto = proyectos[i].descripcionProyecto
    idProyecto = proyectos[i].idProyecto
    cargarProyectos(nombreProyecto, descripcionProyecto, idProyecto)
  }
}

function cargarProyectos(nombreProyecto, descripcionProyecto, idProyecto) {// CON LOS DATOS DE TODOS LOS PROYECTOS SE CARGA EL HTML CON LOS DATOS DE CADA PROYECTO
  var proyectos = `
          <div class="card bg-light">
            <div class="card-body">
              <h5 class="card-title">${nombreProyecto}</h5>
              <p class="card-text">${descripcionProyecto}</p>
              <hr>
              <div class="row">
                <div class="col-md-8 datePorject">
                  <p class="card-text"><small class="text-muted"><i class="far fa-calendar-alt"></i> Fecha Inicio: <b>3
                        mins ago</b> </small> | <small class="text-muted"><i class="far fa-calendar-alt"></i> Fecha Fin:
                      <b>3 mins ago</b> </small></p>
                </div>

                <div class="col-md-4 text-right">
                  <button data-idProyecto=${idProyecto} class="btn btn-info equipos">Ver Equipo</button>
                  <a class="btn btn-secondary" href="http://13.84.151.210/Proyectos" target="_blank">Editar</a> 
                    <a href="#" class="btn btn-danger">Eliminar</a>
                </div>

              </div>
            </div>
          </div>
        `
  $('#proyectos').append(proyectos);
}

$('body').on('click', '.equipos', verEquipo)

function verEquipo() { // se lee la tabla de relacion de equipos y proyectos, y se idenifica el id del equipo
  var idProyecto = $(this).attr('data-idProyecto');
  fetch(`https://ctrelo.azurewebsites.net/api/EquiposProyecto/todos`)
    .then((EquiposProyecto) => {
      return EquiposProyecto.json();
    })
    .then((EquiposProyecto) => {
      for (const i in EquiposProyecto) {
        if (EquiposProyecto[i].idProyecto == idProyecto) {
          var idEquipo = EquiposProyecto[i].idEquipo
          fetch(`https://ctrelo.azurewebsites.net/api/Equipos/uno?id=${idEquipo}`)
            .then((Equipo) => {
              return Equipo.json();
            })
            .then((Equipo) => {
              mostrarEquipo(Equipo)
            })
        }
      }
    })
}

function cargarIntegrantes(idEquipo) {
  fetch('https://ctrelo.azurewebsites.net/api/IntegrantesEquipo/todos')
    .then((respuesta) => {
      return respuesta.json();
    })
    .then((respuesta) => {
      for (const i of respuesta) {
        if (i.idEquipo == idEquipo) {
          fetch(`https://ctrelo.azurewebsites.net/api/Integrantes/uno?id=${i.idIntegrante}`)
            .then((respuesta) => {
              return respuesta.json();
            })
            .then((respuesta) => {
              var idIntegrante = respuesta.idIntegrante
              var integrantes = `
            <div class="d-flex flex-row border rounded">
                      <div class="p-0 col-1">
                        <img src="images/user.png" class="img-fluid border-0" />
                      </div>
                      <div class="pl-3 pt-2 pr-2 pb-2 border-left col-9">
                        <h4 class="text-primary">${respuesta.primerNombre} ${respuesta.primerApellido}<span></span></h4>
                      </div>
                    </div>
                    <div class="row mt-3">
                      <!-- <div class="col-md-4 text-right">
                        <a href="#" class="btn btn-secondary" data-toggle="modal" data-target="#exampleModalScrollable">Editar</a>
                        <a href="#" class="btn btn-danger">Eliminar</a>
                      </div> -->
                    </div>
                    <hr>
          `
              $('#integrantes').append(integrantes);
            })


        }
      }
    })
}

function mostrarEquipo(Equipo) {
  var equipoSelect = `
            <div class="col-md-12 pb-5">
              <!-- item project -->
              <div class="card bg-light">
                <div class="card-body">
                  <h5 data-idEquipo=${Equipo.idEquipo} class="card-title idEquipo">${Equipo.nombreEquipo}</h5>
            

                  <!-- integrante -->
                  <div id="integrantes" class="boxIntegrante">
         
                  </div>
                  <!-- fin integrante -->
                </div>
              </div>
              <!-- fin item team -->
              <!-- fin  col global -->
            </div>
  `
  cargarIntegrantes(Equipo.idEquipo)
  $('#equipoSelect').html(equipoSelect)
  $('#equipos').show();
  $('.proyectos').hide();
  $('#tareas').hide();
}

$('body').on('click', '.proyectosNav', function () {
  $('#equipos').hide();
  $('.proyectos').show();
  $('#tareas').hide();
})

$('#verTareas').click(function (e) {
  e.preventDefault();
  var idEquipo = $('.idEquipo').attr('data-idEquipo')
  fetch('https://ctrelo.azurewebsites.net/api/ActividadesEquipo/todos')
    .then((respuesta) => {
      return respuesta.json();
    })
    .then((respuesta) => {
      for (const i of respuesta) {
        if (i.idEquipo == idEquipo) {
          fetch(`https://ctrelo.azurewebsites.net/api/Actividades/uno?id=${i.idActividad}`)
            .then((respuesta) => {
              return respuesta.json();
            })
            .then((respuesta) => {
              verTareas(respuesta)
            })
        }
      }
    })
});


function verTareas(tareas) {
  console.log(tareas);
  var actividades = `
                <h3 class="card-text">${tareas.nombreActividad}</h3>
                <p>${tareas.descripcionActividad}</p>
                <h6>fecha Inicio: ${tareas.fechaInicio}</h6> 
                <h6>fecha Final: ${tareas.fechaFin}</h6>
    `
  $('#actividades').append(actividades)
  $('#equipos').hide();
  $('.proyectos').hide();
  $('#tareas').show();
}