//Test libs
global using Xunit;
global using FluentAssertions;
global using Bogus;
global using NSubstitute;

//Application libs
global using Microsoft.Extensions.Logging;
global using AutoMapper;

//Core
global using Example.CleanArchitecture.Core.Validators;
global using Example.CleanArchitecture.Core.ValueObjects;
global using Example.CleanArchitecture.Core.Entities;
global using Example.CleanArchitecture.Core.Exceptions;
global using Example.CleanArchitecture.Core.DomainObjects;

//Application
global using Example.CleanArchitecture.Application.Commands.CreateProduct;

//Tests
global using Example.CleanArchitecture.UnitTests.Fixtures.Application;
global using Example.CleanArchitecture.UnitTests.Fixtures.Entities;
global using Example.CleanArchitecture.UnitTests.Fixtures.Commands;
global using Example.CleanArchitecture.UnitTests.Fixtures.Queries;