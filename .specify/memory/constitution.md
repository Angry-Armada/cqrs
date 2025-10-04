<!-- 
Sync Impact Report - Constitution v1.0.0
Version change: Initial → 1.0.0
Modified principles: All principles established for first time
Added sections: Core Principles, Architecture Constraints, Quality Standards, Governance
Removed sections: None (initial version)
Templates requiring updates: 
✅ Updated plan-template.md references
✅ Updated spec-template.md scope alignment  
✅ Updated tasks-template.md task categorization
Follow-up TODOs: None
-->

# Armada CQRS Constitution

## Core Principles

### I. CQRS Pattern Fidelity (NON-NEGOTIABLE)

Commands and queries MUST be strictly separated with no crossover. Commands return acknowledgment types (IDs, Result objects) never data. Queries return data and MUST be side-effect free. All requests flow through dispatchers using the mediator pattern. No direct handler instantiation permitted in application code.

### II. Middleware-First Architecture

Every command, query, and notification MUST support middleware pipeline execution. Middleware registration uses clear global vs. specific patterns. Cross-cutting concerns (logging, validation, authorization) implemented exclusively as middleware. Handlers focus solely on business logic without infrastructure concerns.

### III. Dependency Injection Integration

All components register through IServiceCollection extensions following consistent naming patterns (AddCommandDispatcher, AddQueryHandlers, etc.). Auto-discovery of handlers using Scrutor assembly scanning. Explicit registration required for middleware to maintain pipeline control and ordering.

### IV. Specification-Driven Development

Behavior-driven specifications using Spec Kit (SpecFlow) MUST precede implementation. Feature files define business requirements in Given-When-Then format. Step definitions provide executable specifications. All CQRS scenarios covered: command execution, query handling, middleware behavior, validation flows.

### V. Extensibility Through Composition

Core library remains minimal with extensions in separate packages (FluentValidation, future packages). Extension points clearly defined through interfaces. No breaking changes to core contracts when adding functionality. Backward compatibility maintained across minor versions.

## Architecture Constraints

### Type Safety and Generics

Strong typing enforced throughout: `ICommand<TResponse>`, `IQuery<TResponse>`, `INotification`. Generic constraints ensure compile-time safety. No object or dynamic types in public interfaces. Wrapper pattern isolates reflection to dispatcher layer only.

### Asynchronous Operations

All operations return `Task` or `Task<T>`. CancellationToken support mandatory in all public methods. No synchronous blocking in async contexts. Proper async/await patterns enforced throughout codebase.

### Error Handling Standards

Validation exceptions bubble up from middleware layers. Structured error responses with meaningful messages. No swallowed exceptions. Clear separation between validation errors and system errors.

## Quality Standards

### Testing Requirements

Unit tests for all handlers, middleware, and dispatchers. Integration tests for middleware pipeline behavior. Specification tests for business scenarios using SpecFlow. Sample project serves as integration testing suite and documentation.

### Code Quality Standards

WarningsAsErrors enabled in all projects. Nullable reference types enforced. ImplicitUsings for consistency. No public API changes without specification update. Clear separation of concerns enforced through namespace organization.

### Documentation Standards

XML documentation for all public APIs. README with clear usage examples. Sample project demonstrates real-world usage patterns. Architectural decision records for significant changes.

## Development Workflow

### Feature Development Process

1. Create specification feature file defining behavior
2. Implement step definitions to make specifications executable  
3. Run specifications to verify they fail (red)
4. Implement minimal code to make specifications pass (green)
5. Refactor while keeping specifications green
6. Update sample project to demonstrate new feature

### Extension Development Guidelines

New extensions follow naming pattern: Armada.CQRS.Extensions.{Technology}. Separate NuGet packages for optional dependencies. Integration through middleware registration patterns. No modifications to core library for extension-specific functionality.

## Governance

This constitution supersedes all other development practices and architectural decisions. All pull requests MUST demonstrate compliance with constitutional principles. Complexity additions require explicit justification and approval. Breaking changes require constitutional amendment through documented process.

Amendment procedure: Proposed changes documented in GitHub issue, community discussion period, maintainer approval, version increment, migration guide provided.

**Version**: 1.0.0 | **Ratified**: 2025-10-05 | **Last Amended**: 2025-10-05
