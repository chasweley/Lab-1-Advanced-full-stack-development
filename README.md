# Labb 1 - Avancerad fullstackutveckling

## ER diagram
![ER-diagram - Labb 1](https://github.com/user-attachments/assets/b5ccabaa-5518-4e03-949e-c0aa535490d7)

## User
```c#
GET /api/User/{id}
```
**Response:**
200 OK:
```json
{
  "userId": 1,
  "name": "Charlotte",
  "phoneNo": "07yyyyyyyy"
}
```
404: No user found.

```c#
POST /api/User/Create
```
**Request Body:**
```json
{
  "userId": "0"
  "name": "Charlotte",
  "phoneNo": "07xxxxxxxx"
}
```

**Response:**
200 OK: User created successfully.
400: Failed create user: {reason}

```c#
POST /api/User/Update
```
**Request Body:**
```json
{
  "userId": "1",
  "name": "Charlotte",
  "phoneNo": "07yyyyyyyy"
}
```

**Response:**
200 OK: User updated successfully.
400: Failed to update customer. {reason}

```c#
DELETE /api/User/Delete
```
**Response:**
200 OK: User deleted successfully.
400: Failed to delete user: {reason}

```c#
GET /api/User/
```
**Response:**
200 OK:
```json
{
  "userId": 1,
  "name": "Charlotte",
  "phoneNo": "07yyyyyyy"
},
{
  "name": "Anna",
  "phoneNo": "07zzzzzzzz"
}
```

## Table
```c#
GET /api/Table/{tableId}
```
**Request Body:**
```json
{
  "tableId": 1,
  "seatingCapacity": 12,
}
```
404: No table found.

```c#
POST /api/Table/Create
```
**Request Body:**
```json
{
  "tableId": 0,
  "seatingCapacity": 12
}
```

**Response:**
200 OK: Table successfully created.
400: Failed to create table: {reason}

```c#
POST /api/Table/Update
```
**Request Body:**
```json
{
 "id": 2,
"seatingCapacity": 8
}
```

**Response:**
200 OK: Table successfully updated.
400: Failed to update table: {reason}

```c#
DELETE /api/Table/Delete
```
**Response:**
200 OK: Table successfully deleted.
400: Failed to delete table: {reason}

```c#
GET /api/Table/
```
**Response:**
200 OK:
```json
{
  "tableId": 1,
  "seatingCapacity": 12,
},
{
  "tableId": 2,
  "seatingCapacity": 8,
},
{
  "tableId": 3,
  "seatingCapacity": 4,
}
```

```c#
GET /api/Table/Availability/{dateTime}
```
**Response:**
```json
{
  "id": 2,
  "seatingCapacity": 8,
}
```

## Booking
```c#
GET /api/Booking/{bookingId}
```
**Response:**
200 OK:
```json
{
  "bookingId": 1,
  "noOfCustomers": 12,
  "dateAndTime": "2024-09-01T12:00"
  "userId": "1",
  "tableId": "1"
}
```
404: No booking found.

```c#
POST /api/Booking/Create
```
**Request Body:**
```json
{
  "bookingId": 1,
  "noOfCustomers": 12,
  "dateAndTime": "2024-09-01T12:00"
  "userId": "1",
  "tableId": "1"
}
```

**Response:**
200 OK: Booking created successfully.
400: Failed to create booking: {reason}
400: User was not found.
400: Table was not found.

```c#
POST /api/Booking/Update
```
**Request Body:**
```json
{
  "bookingId": 1,
  "noOfCustomers": 10,
  "dateAndTime": "2024-09-01T12:00"
  "userId": "1",
  "tableId": "1"
}
```

**Response:**
200 OK: Booking updated successfully.
400: Failed to update booking: {reason}

```c#
DELETE /api/Booking/Delete
```
**Response:**
200 OK: Booking deleted successfully.
400: Failed to delete booking: {reason}

```c#
GET /api/Booking
```
**Response:**
200 OK:
```json
{
  "bookingId": 1,
  "noOfCustomers": 10,
  "dateAndTime": "2024-09-01T12:00"
  "userId": "1",
  "tableId": "1"
},
{
  "bookingId": 2,
  "noOfCustomers": 2,
  "dateAndTime": "2024-09-01T18:00"
  "userId": "1",
  "tableId": "2"
}
```
