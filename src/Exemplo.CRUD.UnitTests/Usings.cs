global using Xunit;
global using AutoMapper;
global using Exemplo.CRUD.Application.Commands.CreateProduct;
global using Exemplo.CRUD.Application.ViewModels;
global using Exemplo.CRUD.Core.Entities;
global using Exemplo.CRUD.Core.Exceptions;
global using Exemplo.CRUD.Core.Repositories;
global using Microsoft.Extensions.Logging;
global using NSubstitute;
global using Exemplo.CRUD.Application.Queries.GetById;
global using Exemplo.CRUD.Application.Queries.GetAllProducts;
global using FluentAssertions;
global using Bogus;
global using Exemplo.CRUD.UnitTests.Fixtures.Models;
global using Exemplo.CRUD.UnitTests.Fixtures.Application;
global using Exemplo.CRUD.Core.ValueObjects;
global using Exemplo.CRUD.Application.Commands.DeleteProduct;