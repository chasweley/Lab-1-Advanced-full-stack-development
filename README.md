# Labb 1 - Avancerad fullstackutveckling

## ER diagram
![ER-diagram - Labb 1](https://github.com/user-attachments/assets/b5ccabaa-5518-4e03-949e-c0aa535490d7)

## User
```
GET /api/User/{userId}
```
**Response body:**
200 OK
```json
{
  "userId": 1,
  "name": "Charlotte",
  "phoneNumber": "07yyyyyyyy"
}
```

```
POST /api/User/Create
```
**Request body:**
```json
{
  "name": "Charlotte",
  "phoneNumber": "07xxxxxxxx"
}
```

**Response body:**
200 OK User created successfully.
400 An error occured while trying to create user. {ex.Message}

```
POST /api/User/Update
```
**Request body:**
```json
{
  "userId": "1",
  "name": "Charlotte",
  "phoneNo": "07yyyyyyyy"
}
```

**Response body:**
200 OK User updated successfully.
400 An error occured while trying to update user. {ex.Message}

```
DELETE /api/User/Delete
```
**Response body:**
200 OK User deleted successfully.
400 An error occured while trying to delete user. {ex.Message}

```
GET /api/User/
```
**Response body:**
200 OK
```json
[
  {
    "userId": 1,
    "name": "Charlotte",
    "phoneNumber": "07yyyyyyy"
  },
  {
    "userId": 2,
    "name": "Anna",
    "phoneNumber": "07zzzzzzzz"
  }
]
```

## Table
```
GET /api/Table/{tableId}
```
**Request body:**
```json
{
  "tableId": 1,
  "seatingCapacity": 12
}
```
400: No table found.

```
POST /api/Table/Create
```
**Request body:**
```json
{
  "seatingCapacity": 12
}
```

**Response body:**
200 OK Table successfully created.
400 An error occured while trying to create table. {ex.Message}

```
POST /api/Table/Update
```
**Request body:**
```json
{
  "tableId": 2,
  "seatingCapacity": 8
}
```

**Response body:**
200 OK Table successfully updated.
400 An error occured while trying to update table. {ex.Message}

```
DELETE /api/Table/Delete
```
**Response body:**
200 OK Table successfully deleted.
400 An error occured while trying to delete table. {ex.Message}

```
GET /api/Table/
```
**Response body:**
200 OK
```json
[
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
]
```

```
GET /api/Table/Availability/{dateTime}
```
**Response body:**
```json
{
  "tableId": 2,
  "seatingCapacity": 8
}
```

## Booking
```
GET /api/Booking/{bookingId}
```
**Response body:**
200 OK
```json
{
  "bookingId": 1,
  "numberOfCustomers": 10,
  "dateAndTime": "2024-09-01T12:00:00"
  "userId": "2",
  "tableId": "1"
}
```

```
POST /api/Booking/Create
```
**Request body:**
```json
{
  "numberOfCustomers": 12,
  "bookedDateTime": "2024-09-01T12:00",
  "userId": "2",
  "tableId": "1"
}
```

**Response:**
200 OK Booking created successfully.
400 An error occured while trying to create booking. {ex.Message}
500 User was not found.
500 Table was not found.

```
POST /api/Booking/Update
```
**Request body:**
```json
{
  "bookingId": 1,
  "numberOfCustomers": 10,
  "bookedDateTime": "2024-09-01T12:00:00",
  "userId": "2",
  "tableId": "1"
}
```

**Response body:**
200 OK Booking updated successfully.
400 An error occured while trying to update booking. {ex.Message}

```
DELETE /api/Booking/Delete
```
**Response body:**
200 OK Booking deleted successfully.
400 An error occured while trying to delete booking. {ex.Message}

```
GET /api/Booking
```
**Response body:**
200 OK
```json
[
    {
    "bookingId": 1,
    "numberOfCustomers": 10,
    "bookedDateTime": "2024-09-01T12:00:00",
    "userId": 2,
    "tableId": 1
  },
  {
    "bookingId": 2,
    "numberOfCustomers": 4,
    "bookedDateTime": "2024-09-01T18:30:00",
    "userId": 1,
    "tableId": 2
  }
]
```
400 {ex.Message}

## MenuItem
```c#
POST /api/MenuItem/{menuItemId}
```
**Response body:**
200 OK
```json
{
  "menuItemId": 1,
  "name": "Pancakes",
  "price": 5.99,
  "isAvailable": true
}
```

```c#
POST /api/MenuItem/Create
```
**Request body:**
```json
{
  "name": "Waffles",
  "price": 6.99,
  "isAvailable": true
}
```

**Response body:**
200 OK User created successfully.
400 An error occured while trying to create menu item. {ex.Message}

```c#
POST /api/MenuItem/Update
```
**Request body:**
```json
{
  "menuItemId": 1,
  "name": "Pancakes",
  "price": 5.99,
  "isAvailable": false
}
```

**Response body:**
200 OK Table successfully updated.
400 An error occured while trying to update menu item. {ex.Message}

```c#
DELETE /api/MenuItem/Delete
```
**Response:**
200 OK Menu item deleted successfully.
400 An error occured while trying to delete menu item. {ex.Message}

```c#
GET /api/MenuItem
```
**Response body:**
200 OK
```json
[
  {
    "menuItemId": 1,
    "name": "Pancakes",
    "price": 5.99,
    "isAvailable": false
  },
  {
    "menuItemId": 2,
    "name": "Waffles",
    "price": 6.99,
    "isAvailable": true
  }
]
```
400 {ex.Message}
