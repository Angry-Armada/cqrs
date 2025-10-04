# Spec-Kit Workflow Guide

This document describes the recommended workflow for using the spec-kit integration for behavior-driven specification testing.

## Overview

The spec-kit integration provides a structured approach to feature development using specification-driven development. The workflow ensures that features are properly specified, planned, and implemented with clear traceability from requirements to code.

## Prerequisites

- Git repository initialized
- Spec-kit integration configured (`.specify/` directory present)
- Development environment set up

## Workflow Steps

### 1. Create Feature Branch

Before starting any feature work, create a feature branch. This can be done either:

#### Option A: Via GitHub UI (Recommended)

1. Navigate to your repository on GitHub
2. Click on the branch dropdown (typically showing "main")
3. Type your new branch name and select "Create branch"
4. Checkout the branch locally:

   ```bash
   git fetch origin
   git checkout your-feature-branch-name
   ```

#### Option B: Via Command Line

```bash
git checkout -b feature/your-feature-name
# or
git checkout -b 001-your-feature-name
```

#### Branch Naming Conventions

- **Recommended**: `feature/descriptive-name` (e.g., `feature/user-authentication`)
- **Alternative**: `NNN-descriptive-name` (e.g., `001-user-authentication`)
- **Avoid**: Working directly on `main` or `master` branches

### 2. Run Specify Command

Once you're on your feature branch, create the feature specification:

```bash
# Replace "Your feature description" with actual feature description
/specify Your feature description here
```

#### What happens

- The system detects your current branch name
- Creates a specification folder in `specs/` using your branch name
- Generates initial specification template
- Sets up the feature structure for further development

#### Example

If you're on branch `feature/user-login`, running `/specify Add user login functionality` will:

- Create folder: `specs/feature/user-login/`
- Generate file: `specs/feature/user-login/spec.md`
- Initialize the specification with your feature description

### 3. Continue with Specification Development

After running `/specify`, continue with the standard spec-kit workflow:

1. **Clarify requirements** (optional): `/clarify`
2. **Create implementation plan**: `/plan`
3. **Generate tasks**: `/tasks`
4. **Implement features** following the generated plan

## Directory Structure

```text
project-root/
├── specs/
│   ├── feature/user-login/           # Based on branch name
│   │   ├── spec.md                   # Feature specification
│   │   ├── plan.md                   # Implementation plan
│   │   ├── tasks.md                  # Task breakdown
│   │   └── contracts/                # API contracts
│   └── 001-another-feature/          # Numbered branch example
├── .specify/
│   ├── scripts/
│   └── templates/
└── src/                              # Your application code
```

## Key Benefits

1. **Branch-Spec Alignment**: Specification folders match your branch names, making it easy to track what specs belong to which features
2. **GitHub Integration**: Works seamlessly with GitHub's branch creation workflow
3. **Traceability**: Clear connection between Git branches, specifications, and implementation
4. **Flexible Naming**: Supports both `feature/` prefixed and numbered branch conventions

## Troubleshooting

### Error: "Cannot run specify on main/master branch"

**Solution**: Create and checkout a feature branch before running `/specify`

### Warning: "Branch name doesn't follow recommended conventions"

**Impact**: The command will still work, but consider using recommended naming for better organization

### Error: "You must create and checkout a feature branch"

**Solution**: Ensure you're on a branch other than `main` or `master`

## Best Practices

1. **Always work in feature branches** - Never run `/specify` on main/master
2. **Use descriptive branch names** - Make it clear what the feature does
3. **One feature per branch** - Keep features focused and atomic
4. **Follow the full workflow** - Don't skip specification steps
5. **Review specifications** - Ensure they're complete before implementation

## Integration with Existing Workflows

This workflow integrates well with:

- **GitHub Flow**: Create branch → Make changes → Create PR → Merge
- **Git Flow**: Feature branches are part of the standard Git Flow model
- **CI/CD**: Automated testing can run against feature branches
- **Code Review**: Specifications can be reviewed alongside code changes

## Next Steps

After setting up your specification:

1. Review and refine the generated spec
2. Run `/clarify` if any requirements are unclear
3. Execute `/plan` to create implementation plan
4. Use `/tasks` to break down the work
5. Begin implementation following the plan
