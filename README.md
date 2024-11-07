# Migrar Datos

Proyecto de .net 8 que tiene como objetivo poder trabajar con csv y migraciones de datos de csv a sql server

## Puntos a tocar

1. Leer CSV
2. Crear y escribir en un nuevo csv
3. Insertar datos, junto el tiempo que tarda

## Customer Schema

CustomerId
First Name
Last Name
Company
City
Country
Phone 1
Phone 2
Email
Subscription Date
Website

## Importante

A pesar de que AddRange() sea mas rapido, no es la recomendada. Y tampoco es recomendado hacer el db.SaveChanges() fuera del bucle.

Lo recomendado es usar dentro del bucle el .Add(...) y el .SaveChanges().
Encontraras esta forma en Migracion.InsertarDatosSaveChangesDentroDelBucle(...)

Aunque tardes mas, esto te permite saber en caso de que falle el guardar el item, saber en que item ha fallado y los motivos. Ademas de poder debugear.