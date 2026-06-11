# EF Core Migrations Guide - PostgreSQL

## Database Setup

### 1. Environment Configuration

Create or update `.env` file in project root:
```env
DB_PASSWORD=your_postgres_password
ASPNETCORE_ENVIRONMENT=Development
```

**Note:** Copy from `.env.example` if needed:
```bash
copy .env.example .env
```

Then edit `.env` and set your PostgreSQL password.

### 2. PostgreSQL Connection String

Connection string is in `src/Be_Ktl.API/appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=be_ktl;Username=postgres;Password=${DB_PASSWORD}"
}
```

The `${DB_PASSWORD}` placeholder is replaced from `.env` file at runtime.

### 3. Create Initial Migration
```bash
cd src/Be_Ktl.Infrastructure
dotnet ef migrations add InitialCreate --project . --startup-project ../Be_Ktl.API --context ApplicationDbContext
```

### 4. Apply Migration to Database
```bash
cd src/Be_Ktl.Infrastructure
dotnet ef database update --project . --startup-project ../Be_Ktl.API --context ApplicationDbContext
```

## Migration Commands

### Add New Migration
```bash
dotnet ef migrations add MigrationName --project src/Be_Ktl.Infrastructure --startup-project src/Be_Ktl.API --context ApplicationDbContext
```

### Remove Last Migration (if not applied to database)
```bash
dotnet ef migrations remove --project src/Be_Ktl.Infrastructure --startup-project src/Be_Ktl.API --context ApplicationDbContext
```

### List All Migrations
```bash
dotnet ef migrations list --project src/Be_Ktl.Infrastructure --startup-project src/Be_Ktl.API --context ApplicationDbContext
```

### Update Database to Specific Migration
```bash
dotnet ef database update MigrationName --project src/Be_Ktl.Infrastructure --startup-project src/Be_Ktl.API --context ApplicationDbContext
```

### Generate SQL Script (without applying)
```bash
dotnet ef migrations script --project src/Be_Ktl.Infrastructure --startup-project src/Be_Ktl.API --context ApplicationDbContext --output migration.sql
```

## PostgreSQL Setup

### Prerequisites
- PostgreSQL 12+ installed
- psql client available in PATH

### Create Database

```sql
-- Connect to PostgreSQL
psql -U postgres

-- Create database
CREATE DATABASE be_ktl;

-- Verify
\l
```

Or via command line:
```bash
createdb -U postgres be_ktl
```

### Verify Connection

```bash
psql -U postgres -d be_ktl -h localhost -p 5432
```

## DbContext Configuration

- **Location**: `src/Be_Ktl.Infrastructure/Persistence/ApplicationDbContext.cs`
- **Configurations**: `src/Be_Ktl.Infrastructure/Configurations/`
- **Startup**: Registered in `src/Be_Ktl.API/Program.cs` via `AddInfrastructure()`
- **Environment Loader**: `.env` file loader in `Program.cs`

## Entity Configuration Files

All entities have individual configuration files with proper:
- ✅ Primary keys (Guid)
- ✅ Foreign keys with cascade delete
- ✅ Indexes (unique, soft-delete, performance)
- ✅ String length constraints
- ✅ Enum conversions
- ✅ Relationships (1-to-many, many-to-many, one-to-one)

### Configured Entities
- ✅ User, Role, UserRole, Permission, RolePermission
- ✅ Instructor, Category, Course, Chapter, Lesson, Video
- ✅ LessonResource, CourseObjective, CourseRequirement
- ✅ Cart, CartItem, Order, OrderItem, Payment, Coupon
- ✅ Enrollment, Review, Certificate, Notification
- ✅ LessonProgress, Livestream, UserSession, Wishlist

## Database Features

### Soft Delete Support
- All entities inherit from `BaseEntity` with `IsDeleted` flag
- Indexes created on `IsDeleted` for query performance
- Restore and SoftDelete methods in BaseEntity

### Relationships
- User → multiple Roles (many-to-many via UserRole)
- Role → multiple Permissions (many-to-many via RolePermission)
- Course → Chapters → Lessons → Video + Resources
- Category → Courses (with optional parent category)
- Student → Enrollments, Orders, Carts, Reviews, Wishlists
- Instructor → Courses, Livestreams

### Constraints
- Email unique at User level
- Course Slug unique
- Coupon Code unique
- User-Role, Role-Permission, Student-Lesson Progress are composite unique
- Student-Course Enrollment is composite unique

## Troubleshooting

### "DB_PASSWORD environment variable not found"
Solution: Ensure `.env` file exists with `DB_PASSWORD` set before running app

### "Cannot connect to database"
Solutions:
- Check PostgreSQL is running: `pg_isready -h localhost -p 5432`
- Verify password in `.env` file
- Check database exists: `psql -U postgres -l | grep be_ktl`

### Migration stuck or corrupted
```bash
# View migration history
dotnet ef migrations list --project src/Be_Ktl.Infrastructure --startup-project src/Be_Ktl.API

# Rollback to previous state
dotnet ef database update PreviousMigrationName --project src/Be_Ktl.Infrastructure --startup-project src/Be_Ktl.API
```
