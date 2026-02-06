<script lang="ts">
	import { cn } from '$lib/utils.js';
	import { Button } from '$lib/components/ui/button/index.js';
	import * as Field from '$lib/components/ui/field/index.js';
	import { Input } from '$lib/components/ui/input/index.js';
	import type { HTMLAttributes } from 'svelte/elements';
	import { registerBaseSchema, registerSchema } from '@/forms';
	import HelperText from '../common/HelperText.svelte';

	let { class: className, ...restProps }: HTMLAttributes<HTMLFormElement> = $props();
	let formData = $state({
		FullName: '',
		Email: '',
		Password: '',
		PasswordConfirm: ''
	});

	let errors: Record<string, string> = $state({});
	let touched: Record<string, boolean> = $state({});

	function validateField(field: keyof typeof formData) {
		const partial = registerBaseSchema.pick({ [field]: true } as any);
		const result = partial.safeParse({ [field]: formData[field] });

		if (!result.success) {
			errors[field] = result.error.issues[0].message;
		} else {
			delete errors[field];
		}
	}

	function validatePasswords() {
		const result = registerSchema.safeParse(formData);

		const issue = result.success
			? null
			: result.error.issues.find((i) => i.path[0] === 'PasswordConfirm');

		if (issue) {
			errors.PasswordConfirm = issue.message;
		} else {
			delete errors.PasswordConfirm;
		}
	}

	function onBlur(field: keyof typeof formData) {
		touched[field] = true;
		validateField(field);
	}

	function onSubmit(event: SubmitEvent) {
		event.preventDefault();

		// mark everything touched
		Object.keys(formData).forEach((key) => (touched[key] = true));

		const result = registerSchema.safeParse(formData);

		if (!result.success) {
			errors = Object.fromEntries(
				result.error.issues.map((issue) => [issue.path[0] as string, issue.message])
			);
			return;
		}

		// fully valid data
		console.log('SUBMIT OK', result.data);

		// continue: API call, navigation, etc.
	}
</script>

<form onsubmit={onSubmit} class={cn('flex flex-col gap-6', className)} {...restProps}>
	<Field.Group>
		<div class="flex flex-col items-center gap-1 text-center">
			<h1 class="text-2xl font-bold">Create your account</h1>
			<p class="text-sm text-balance text-muted-foreground">
				Fill in the form below to create your account
			</p>
		</div>
		<Field.Field>
			<Field.Label for="FullName">Full Name</Field.Label>
			<Input
				id="FullName"
				type="text"
				class={`${errors?.['FullName'] ? 'border-destructive' : ''}`}
				bind:value={formData.FullName}
				onblur={() => onBlur('FullName')}
				oninput={() => touched.FullName && validateField('FullName')}
				placeholder="John Doe"
			/>
			<HelperText variant="error" message={errors?.['FullName'] || ''} show={!!errors?.['FullName']}
			></HelperText>
		</Field.Field>
		<Field.Field>
			<Field.Label for="Email">Email</Field.Label>
			<Input
				id="Email"
				type="email"
				bind:value={formData.Email}
				class={`${errors?.['Email'] ? 'border-destructive' : ''}`}
				placeholder="m@example.com"
				onblur={onBlur.bind(null, 'Email')}
				oninput={() => touched.Email && validateField('Email')}
			/>
			<HelperText variant="error" message={errors?.['Email'] || ''} show={!!errors?.['Email']}
			></HelperText>
		</Field.Field>
		<Field.Field>
			<Field.Label for="Password">Password</Field.Label>
			<Input
				id="Password"
				bind:value={formData.Password}
				onblur={onBlur.bind(null, 'Password')}
				oninput={() => touched.Password && validateField('Password')}
				class={`${errors?.['Password'] ? 'border-destructive' : ''}`}
				type="password"
			/>
			<HelperText
				variant={errors?.['Password'] ? 'error' : 'info'}
				message={'Must be at least 8 characters long.'}
			></HelperText>
		</Field.Field>
		<Field.Field>
			<Field.Label for="passwordConfirm">Confirm Password</Field.Label>
			<Input
				id="passwordConfirm"
				class={`${errors?.['PasswordConfirm'] ? 'border-destructive' : ''}`}
				bind:value={formData.PasswordConfirm}
				onblur={validatePasswords}
				oninput={() => touched.PasswordConfirm && validateField('PasswordConfirm')}
				type="password"
			/>
			<HelperText
				variant="error"
				message={errors?.['PasswordConfirm'] || ''}
				show={!!errors?.['PasswordConfirm']}
			></HelperText>
		</Field.Field>
		<Field.Field>
			<Button type="submit">Create Account</Button>
		</Field.Field>
		<Field.Field>
			<Field.Description class="px-6 text-center">
				Already have an account? <a href="/login">Log in</a>
			</Field.Description>
		</Field.Field>
	</Field.Group>
</form>
