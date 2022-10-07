//Test libs
global using Xunit;
global using FluentAssertions;
global using Bogus;
global using NSubstitute;
global using NSubstitute.ExceptionExtensions;

//Application libs
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Logging;
global using AutoMapper;
global using MediatR;

//API
global using Example.CleanArchitecture.API.Features.V1.Controllers;

//Application
global using Example.CleanArchitecture.Application.Commands.CreateProduct;
global using Example.CleanArchitecture.Application.Commands.UpdateProduct;
global using Example.CleanArchitecture.Application.Commands.DeleteProduct;
global using Example.CleanArchitecture.Application.Queries.GetProductById;
global using Example.CleanArchitecture.Application.Queries.GetProducts;
global using Example.CleanArchitecture.Application.ViewModels;
global using Example.CleanArchitecture.Application.Services;
global using Example.CleanArchitecture.Application.Queries.GetSales;

//Core
global using Example.CleanArchitecture.Core.Validators;
global using Example.CleanArchitecture.Core.ValueObjects;
global using Example.CleanArchitecture.Core.Entities;
global using Example.CleanArchitecture.Core.Exceptions;
global using Example.CleanArchitecture.Core.DomainObjects;
global using Example.CleanArchitecture.UnitTests.Fixtures.API;

//Tests
global using Example.CleanArchitecture.UnitTests.Fixtures.Application;
global using Example.CleanArchitecture.UnitTests.Fixtures.Entities;
global using Example.CleanArchitecture.UnitTests.Fixtures.Commands;
global using Example.CleanArchitecture.UnitTests.Fixtures.Queries;
global using Example.CleanArchitecture.UnitTests.Fixtures.Application.ViewModels;
global using Example.CleanArchitecture.UnitTests.Fixtures.API.Controllers;
global using Example.CleanArchitecture.UnitTests.Fixtures.Application.Commands;
global using Example.CleanArchitecture.UnitTests.Fixtures.Core.Entities;
global using Example.CleanArchitecture.UnitTests.Fixtures.Application.Queries;