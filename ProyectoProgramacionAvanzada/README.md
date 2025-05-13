Sistema de Gestión de Reservas Médicas en C# y .NET con MySQL
Este proyecto forma parte del trabajo universitario para el curso de ACA. Se trata de una aplicación desarrollada en C# con .NET y conexión a una base de datos MySQL, que permite gestionar las reservas de consultorios médicos en una clínica u hospital.

📌 Descripción General
El sistema tiene como objetivo permitir el registro de pacientes, médicos, especialidades y la programación de citas médicas. Toda la información se almacena en una base de datos MySQL.

🗃️ Estructura de la Base de Datos
Las principales tablas que componen el sistema son:

Paciente: id, nombre, apellido, documento, email, teléfono, fecha_nacimiento

Médico: id, nombre, especialidad, email, teléfono, consultorio

Especialidad: id, nombre (ej: pediatría, cardiología, dermatología)

Cita: id, id_paciente, id_medico, fecha_cita, hora, motivo, estado (pendiente, atendida, cancelada)

🧩 Funcionalidades Principales
Registro y edición de pacientes y médicos

Agendamiento de citas médicas

Visualización de citas por fecha, médico o paciente

Cancelación y modificación de citas