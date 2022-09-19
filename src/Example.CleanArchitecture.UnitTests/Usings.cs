//Test libs
global using Xunit;
global using FluentAssertions;
global using Bogus;
global using NSubstitute;

//Application libs
global using Microsoft.Extensions.Logging;
global using AutoMapper;
global using MediatR;

//API
global using Example.CleanArchitecture.API.Controllers;

//Application
global using Example.CleanArchitecture.Application.Commands.CreateProduct;
global using Example.CleanArchitecture.Application.Queries.GetProductById;
global using Example.CleanArchitecture.Application.ViewModels;

//Core
global using Example.CleanArchitecture.Core.Validators;
global using Example.CleanArchitecture.Core.ValueObjects;
global using Example.CleanArchitecture.Core.Entities;
global using Example.CleanArchitecture.Core.Exceptions;
global using Example.CleanArchitecture.Core.DomainObjects;

//Tests
global using Example.CleanArchitecture.UnitTests.Fixtures.Application;
global using Example.CleanArchitecture.UnitTests.Fixtures.Entities;
global using Example.CleanArchitecture.UnitTests.Fixtures.Commands;
global using Example.CleanArchitecture.UnitTests.Fixtures.Queries;
global using Example.CleanArchitecture.UnitTests.Fixtures.Application.ViewModels;