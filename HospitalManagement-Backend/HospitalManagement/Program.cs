var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDataAccess<Doctor, int>, DoctorDataAccess>();
builder.Services.AddScoped<IServiceRepository<Doctor, int>, DoctorRepository>();
builder.Services.AddScoped<IDataAccess<Nurse, int>, NurseDataAccess>();
builder.Services.AddScoped<IServiceRepository<Nurse, int>, NurseRepository>();
builder.Services.AddScoped<IDataAccess<Ward, int>, WardDataAccess>();
builder.Services.AddScoped<IServiceRepository<Ward, int>, WardRepository>();
builder.Services.AddScoped<IDataAccess<Wardboy, int>, WardboyDataAccess>();
builder.Services.AddScoped<IServiceRepository<Wardboy, int>, WardboyRepository>();
builder.Services.AddScoped<IDataAccess<Room, int>, RoomDataAccess>();
builder.Services.AddScoped<IServiceRepository<Room, int>, RoomRepository>();
builder.Services.AddScoped<IDataAccess<MedicineStore, int>, MedicineStoreDataAccess>();
builder.Services.AddScoped<IServiceRepository<MedicineStore, int>, MedicineStoreRepository>();
builder.Services.AddScoped<IDataAccess<Canteen, int>, CanteenDataAccess>();
builder.Services.AddScoped<IServiceRepository<Canteen, int>, CanteenRepository>();
builder.Services.AddScoped<IDataAccess<Bill, int>, BillDataAccess>();
builder.Services.AddScoped<IServiceRepository<Bill, int>, BillRepository>();
builder.Services.AddScoped<IDataAccess<Patient, int>, PatientDataAccess>();
builder.Services.AddScoped<IServiceRepository<Patient, int>, PatientRepository>();
builder.Services.AddScoped<IDataAccess<MedicineBill, int>, MedicineBillDataAccess>();
builder.Services.AddScoped<IServiceRepository<MedicineBill, int>, MedicineBillRepository>();
builder.Services.AddScoped<IDataAccess<CanteenBill, int>, CanteenBillDataAccess>();
builder.Services.AddScoped<IServiceRepository<CanteenBill, int>, CanteenBillRepository>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddCors(option =>
{
    option.AddPolicy("corspolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.UseRouting();
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
