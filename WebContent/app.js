const beamsClient = new PusherBeams.Client({
    instanceId: 'f013d668-a533-4fdd-8680-d3f8e930b99d' // Replace with your Instance ID
});

async function registerDevice() {
    const userId = 'user-id'; // Use a unique user ID for your app
    await beamsClient.start();
    await beamsClient.addDeviceInterest(userId);
    console.log('Device registered with user ID:', userId);
}

