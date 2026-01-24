<script lang="ts">
 import * as Card from "$lib/components/ui/card/index.js";
 import type { Movie } from "../../../types/movie";

 const {imgUrl,title} : Movie = $props();
</script>
 
<Card.Root class="mx-auto w-full max-w-sm">
    <Card.Content>
        <img src={imgUrl} alt={`${title} image`} />
    </Card.Content>
 
    <Card.Footer class="flex-col gap-2">
        <div class="text-lg">{title}</div>
    </Card.Footer>
</Card.Root>